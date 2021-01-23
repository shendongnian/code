    // Make this public so it will be available in the inspector. Check what game object is attached to
    // Drag the Text into the MyInputField.
   
    public Text MyInputField;
    form.AddField(MyInputField.text, myinput);
    // If you don't like Dragging it from the Inspector or don't want your Myinputfield to be public
    // You can use GameObject.Find("MYinputFieldName").GetComponent<Text>();
    // GameObject.Find is Slow and should be avoided if you're Performance concious.
    
