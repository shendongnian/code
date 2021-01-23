    Button button2 = new Button();
    PostBackTrigger pTrigger = new System.Web.UI.PostBackTrigger() { ControlID = button2.ID };
    updatePanel1.Triggers.Add(pTrigger);
    
    DIV2.Controls.Add(button2);
    
