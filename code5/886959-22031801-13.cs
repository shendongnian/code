    var thisstdlist = (List<Student>)Session["stdlist"];
    // If a key isn't found in Session, it will be null ..
    if (thisstdlist == null)
    {
        // i.e. only re-initialize if it was missing from session
        thisstdlist = new List<Student>();
        // You don't need to continually reassign the session variable
        Session["stdlist"] = thisstdlist;
    }
    // Adds to the list; now that Session also has a reference to the same list
    thisstdlist.Add(new Student(txtsid.Text,txtsname.Text));
