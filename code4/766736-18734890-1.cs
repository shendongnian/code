    private void ResolveTaskServices()
    {
        if (!servicesResolved)
        {
          foreach (Type t in taskServiceTypes)
            {
              //Resolve Service via Reflection and add it to the List of Services
              MethodInfo MethodObj = typeof(TasksService).GetMethod("ResolveService");
              MethodInfo GenericMethodObj = MethodObj.MakeGenericMethod(t);
              taskServices.Add((ITaskService)GenericMethodObj.Invoke(this, new object[] { }));
            }
    
          servicesResolved = true;
        }
    }
