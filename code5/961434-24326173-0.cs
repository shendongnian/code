    List<int> pagesid = new List<int>();//int array
    HashSet<int> deletepages = null;
    foreach (XmlNode rule in pgmgmtrules)
    {
      ruleresult=doc.ParseText(rule.InnerText, false);//parse rule
      if (ruleresult != "")
      { //if parsed rule result has value
        if (rule.Attributes["Action"].Value == "Delete")
        {
          var text=rule.Attributes["pageids"].Value;                                     
          pagesid.AddRange(text.Split(',').Select(int.Parse));
        }
      }
    }
    //add elements from pagesid array to hashset
    deletepages =  new HashSet<int>(pagesid);
