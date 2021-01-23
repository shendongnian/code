    var libs = kernel.GetAll<ILibrary>();
                foreach (var lib in libs)
                {
                    lib.Method();
                }
