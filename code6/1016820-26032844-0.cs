    List<temp> tempLIst = new List<temp>();
    tempLIst.Add(new temp() { Id = 1, code = "111", name = "first", username = "user first" });
    tempLIst.Add(new temp() { Id = 1, code = "222", name = "second", username = "user second" });
    tempLIst.Add(new temp() { Id = 1, code = "333", name = "third", username = "user third" });
    tempLIst.Add(new temp() { Id = 1, code = "444", name = "four", username = "user four" });
    ViewBag.name = new SelectList(tempLIst, "username", "name");
    return View();
