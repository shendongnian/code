        public void RefreshLuaVariables(Lua luaVM)
        {
            while (true)
            {
                try
                {
                    luaVM["PlayerX"] = vsc.PlayerX;
                    ...
                    luaVM["TargetX"] = vsc.TargetX;
                    ...
                    luaVM["SystemDate"] = DateTime.Now.ToString();
                }
                catch (Exception e)
                {
                   Print(e.Message);
                }
                Thread.Sleep(100);             
            }
        }
