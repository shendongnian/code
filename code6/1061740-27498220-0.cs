        List<string> successBenefitCodes = new List<string>();
        foreach(var ben in youritems)
        {
        successBenefitCodes.Add(ben.BenefitCode.ToString());
        }
        ViewState["successBenefitCodes"] = successBenefitCodes.ToArray();
