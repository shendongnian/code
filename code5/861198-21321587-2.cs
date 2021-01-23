    public bool IsReferencedByAnyVehicle(Car car)
    {
        ulong ptr;
        // Nasty way of getting address 
        unsafe
        {
            TypedReference tr = __makeref(car);
            ptr = (ulong)(**(IntPtr**)(&tr));
            Console.WriteLine(ptr);
        }
        // Attach to the process itself, hence only AttachFlag.Passive flag is possible
        var process = Process.GetCurrentProcess();
        using (var dataTarget = DataTarget.AttachToProcess(process.Id, 250, AttachFlag.Passive))
        {
            string dacLocation = dataTarget.ClrVersions[0].TryGetDacLocation();
            ClrRuntime runtime = dataTarget.CreateRuntime(dacLocation);
            ClrHeap heap = runtime.GetHeap();
            // Get all Vehicle objects from heap that has reference to ptr
            var refs = heap.EnumerateObjects()
                .Select(obj => new
                {
                    Type = heap.GetObjectType(obj),
                    ObjectAddress = obj
                })
                .Where(t => t.Type != null &&
                            t.Type.Name.EndsWith("Vehicle") &&
                            GetReferences(t.Type, t.ObjectAddress).Contains(ptr))
                .Any();
            // Cleanup
            runtime.Flush();
            return refs;
        }
    }
    public List<ulong> GetReferences(ClrType type, ulong objRef)
    {
        var result = new List<ulong>();
        type.EnumerateRefsOfObjectCarefully(objRef, (addr, _) => result.Add(addr));
        return result;
    }
