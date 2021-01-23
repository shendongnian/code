     public static void Quit()
            {
                if (Environment.OSVersion.Version.Major < 8)//try to load XNA assemblies (only working on WP7)
                {
                    System.Reflection.Assembly asmb = System.Reflection.Assembly.Load("Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553");
                    asmb = System.Reflection.Assembly.Load("Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553");
                    Type type = asmb.GetType("Microsoft.Xna.Framework.Game");
                    object obj = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    type.GetMethod("Exit").Invoke(obj, new object[] { });
                }
                else// => WP8
                {
                    Type type = Application.Current.GetType();
                    type.GetMethod("Terminate").Invoke(Application.Current, new object[] { });
                }
            }
