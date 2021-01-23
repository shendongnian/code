    void button_click(object sender,eventsarg e)
    {
        MyObj.URL = App.Locator.MyVM.MyDefineAddinModel.URL;// App.Locator because MVVMLight is tagged
        MyObj.TemplateType = App.Locator.MyVM.MyDefineAddinModel.TemplateType ;
    }
