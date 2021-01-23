    var keepLooping = true;
    var switchCaseSwitch = param.Component.Type;
    
    while(keepLooping)
    {
        switch (switchCaseSwitch)
        {
            case "Combo":
                returnComboItemSelect = generateCB(param);
                if (returnComboItemSelect == "Slider")
                {
                    switchCaseSwitch = "Slider";
                }
                else
                {
                    keepLooping = false;
                }
                break;                            
            case "List":
                returnSomething = generateL(param);
                keepLooping = false;
                break;
            case "Slider":
                returnSomething = generateSl(param,1);
                keepLooping = false;
                break;
            case "RadioButtons":
                returnSomething = generateRB(param);
                keepLooping = false;
                break;
            case "CheckBox":
                returnSomething = generateCHB(param,flag);
                keepLooping = false;
                break;
            default:
                throw new Exception("Unknown component type");
         }
    }
