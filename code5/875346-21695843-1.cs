            var assembly        = Assembly.GetExecutingAssembly();
            var resourceManager = new ResourceManager(assembly.GetName().Name + ".MainForm", assembly);
            using ( Stream resourceStream = resourceManager.GetStream("SignInSound") )
            {
                using ( SoundPlayer player = new SoundPlayer(resourceStream) )
                {
                    player.PlaySync();
                }
            }
