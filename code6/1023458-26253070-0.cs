    ScriptControl scriptControl= new ScriptControl{ initialise your object here };
 
    Dictionary<string, object> inputDictionary = new Dictionary<string, object> { { "ScriptControl", scriptControl } };
 
    var output = WorkflowInvoker.Invoke(workflow, inputDictionary );
