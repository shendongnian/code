     public void ClassGet(string Class, List<string> Methodlist)
            {
                Type ClassType;
                switch (Class)
                {
                    case "Gold":
                        ClassType = typeof(Gold); break;//Declare the type by Class name string
                    case "Coin":
                        ClassType = typeof(Coin); break;
                    default:
                        ClassType = null;
                        break;
                }
                if (ClassType != null)
                {
                    object Instance = Activator.CreateInstance(ClassType); //Create instance from the type
                    
                }
    
            }
