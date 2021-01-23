    <#
    foreach (var type in typesToRegister.Where(t => t.IsClass && !t.IsAbstract))
    {#>
       [DataContract(Name="<#= ConvertToCamelCase(type.Name) #>]
       public partial class <#= GetDTOClassName(type.Name) #>
       {
          <# foreach (var property in type.GetProperties())
          {#>
             // analyze property type
             // and generate appropriate DataMember property
          <#}#>
       }
    <#}#>
