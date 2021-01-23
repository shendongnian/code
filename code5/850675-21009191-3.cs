    this.txt.ShouldReturn = textField =>
    {
        (new Action(async () =>
        {
            try
            {
                await this.HandleNextStep();
                // executed synchronously until this point
                Debug.Print("NextStepHandled");
            }
            catch (Exception ex)
            {
                // catch all exceptions inside "async void" lambda
                Debug.Print(ex.Message);
            }
        }))();
        return true;
    };
