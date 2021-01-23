    open System.Collections.Generic
    open System.Data
    open System.Dynamic
    open System.Runtime.CompilerServices
    [<CompiledName("ToDynamic")>]
    let toDynamic (reader: IDataReader) : [<return: Dynamic([|false;true|])>] ResizeArray<obj> = 
      let results = ResizeArray<obj>()
      let rec loop() =
        if reader.Read() then
          let obj = ExpandoObject() :> IDictionary<_,_>
          for i = 0 to reader.FieldCount - 1 do
            obj.Add(reader.GetName(i), if reader.IsDBNull(i) then null else reader.[i])
          results.Add(obj)
          loop()
        else results
      loop()
