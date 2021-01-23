    <#
    // get a reference to the project of this t4 template
    var project = VisualStudioHelper.CurrentProject;
    
    // get all class items from the code model
    var allClasses = VisualStudioHelper.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false);
    
    // iterate all classes
    foreach(EnvDTE.CodeClass codeClass in allClasses)
    {
            // get all attributes this method is decorated with
            var allAttributes = VisualStudioHelper.GetAllCodeElementsOfType(codeClass.Attributes, vsCMElement.vsCMElementAttribute, false);
            // check if the SomeProject.AutoExtendedAttribute is present
            if (allAttributes.OfType<EnvDTE.CodeAttribute>()
                             .Any(att => att.FullName == "SomeProject.AutoExtended"))
            {
            #>
            // this class has been generated
            public partial class <#= codeClass.FullName #>
            {
              <#
              // now get all methods implemented by the class
              var allFunctions = VisualStudioHelper.GetAllCodeElementsOfType(codeClass.Members, EnvDTE.vsCMElement.vsCMElementFunction, false);
              foreach(EnvDTE.CodeFunction function in allFunctions)
              {
              #>
                  public static <#= function.FullName #> etc...
              <#
              } 
              #>
            }
    <#          
            }
        }
    }
    #>
