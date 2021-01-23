     rulesList = ruleSet.Rules.ToList();
     for (int i = 0; i < rulesList.Count; i++)
            {
                rulesList[i] = "sddfs";
                if(rulesList[i].ThenAction == "this.MacroLoop.Current.Strategy.SubStrategy.Current.Block.AIN.HLOP = 0")
                    {
                            rulesList[i].ThenAction = "this.MacroLoop.Current.Strategy.SubStrategy.Current.Block.AIN.HLOP = 1";
                    }
            }
