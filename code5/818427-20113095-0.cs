    public void RunNumber() {
        for (int i = 0; i < 25; i++) {
            var model = indexModel();
            model.Number = i;
            Session["IndexModel"] = model;
            Thread.Sleep(1000);
        }
    }
