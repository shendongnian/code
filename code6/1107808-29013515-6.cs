    protected void btnTeste_Click(object sender, EventArgs e)
    {
        myList.Add(new Foo { Id = 0, Name = "Nobody" });
        ViewState["myList"] = myList; //save it back in session
    }
