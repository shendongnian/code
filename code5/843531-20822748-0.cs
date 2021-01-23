    IBL bl;
    switch (ddlPlan.SelectedValue)
    {
        case "2": bl = new BL_02(); break;
        case "3": bl = new BL_03(); break;
        case "5": bl = new BL_05(); break;
    }
    bl.DeleteQues(Id, Version);
