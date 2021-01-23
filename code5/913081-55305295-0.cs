                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
            }
            ms.Seek(0, SeekOrigin.Begin);
            Assembly assembly = Assembly.Load(ms.ToArray());
            Type type = assembly.GetType("TestAccountScrubbing.AccountScubbing");
            object obj = Activator.CreateInstance(type);
            var returnValue =type.InvokeMember("Main",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                obj,
                new object[] { "Hello World" });
            }
