    List<ControlResult> results = new List<ControlResult>();
    results.Add(makeControlResult(_nameFieldID, "Name", "Bob Jones"));
    results.Add(makeControlResult(_emailFieldID, "Email", "B.Jones@test.com"));
    results.Add(makeControlResult(_messageFieldID, "Message", "Lorem ipsum. Dolor sit amet."));
    Item formItem = Sitecore.Context.Database.GetItem(_yourFormID);
    SitecoreSimpleForm simpleForm = new SitecoreSimpleForm(formItem);
    var saveActionXml = simpleForm.FormItem.SaveActions;
    var actionList = Sitecore.Form.Core.ContentEditor.Data.ListDefinition.Parse(saveActionXml);
    List<ActionDefinition> actionDefinitions = new List<ActionDefinition>();
    actionDefinitions.AddRange(actionList.Groups.SelectMany(x => x.ListItems).Select(li => new ActionDefinition(li.ItemID, li.Parameters) { UniqueKey = li.Unicid }));
    Sitecore.Form.Core.Submit.SubmitActionManager.Execute(_formID, results.ToArray(), actionDefinitions.ToArray());
The set of save actions and their configuration is saved in the Item for your form, but you have to wrap the item in a SitecoreSimpleForm object to get it out. What you get back is XML, so you then need to parse it with the Sitecore.Form.Core.ContentEditor.Data.ListDefinition.Parse() method in order to get back a set of deserialised Save Action objects. However, they're not the right sort of objects for the SubmitActionManager so you need to project them into ActionDefinition objects in order to make use of them.
(Note that the Save Action objects you get after parsing the XML aren't in a flat list, so you need to use something like SelectMany() to flatten it before using them)
The makeControlResult() method referenced above is just to make the snippet clearer. It just creates a ControlResult object from the data about a form field:
    public ControlResult makeControlResult(string fieldID, string fieldName, string fieldValue)
    {
        return new ControlResult(fieldName, fieldValue, string.Empty)
        {
            FieldID = fieldID,
            FieldName = fieldName,
            Value = fieldValue, 
            Parameters = string.Empty
        };
    }
