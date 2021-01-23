            // What the user entered
            var sInputClassName = "Test";
            // The name of the assembly; there are other ways to get this, such as through reflection
            const string CLASS_ASSEMBLY_NAME = "WindowsFormsApplication1";
            // Get the requested type from the entered class name and assembly name
            var oType = Type.GetType(CLASS_ASSEMBLY_NAME + "." + sInputClassName, true);
            if (oType != null) {
                // Once we have the class type, create an instance of it
                var oClass = Activator.CreateInstance(oType, false);
                if (oClass != null) {
                    System.Diagnostics.Debug.WriteLine("Created " + sInputClassName);
                } else {
                    System.Diagnostics.Debug.WriteLine("Could not create " + sInputClassName);
                }
            } else {
                System.Diagnostics.Debug.WriteLine("Could not find " + sInputClassName);
            }
