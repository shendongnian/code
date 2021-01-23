    <input type="submit" name="submit" value="Save" class="btn"/>
    <input type="submit" name="submit" value="Submit" class="btn" />
    [HttpPost]
    public ActionResult Edit(Model md, string submit)
    {
        if (submit == "Save")
        {
            // Code for function 1
        }
        else if (submit == "Submit")
        {
            // code for function 2
        }
    }
