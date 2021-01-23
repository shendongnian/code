        <#
          // the enumeration object you already seem to have
          EnvDTE.CodeEnum theEnum;
          // iterate all enumeration items
          foreach(EnvDTE.CodeVariable variable in theEnum.Members)
          {
              // render name and value
              #><#= variable.Prototype #> = <#= variable.InitExpression.ToString() #>
        <#}
        #>
