    using UnityEngine.UI;
    [SerializeField] private InputField _userField;
    [SerializeField] private InputField _passField;
    
    // Other code.
    public void UserInput()
    {
        string username = _userField.text;
        // Code that uses the username variable.
    }
    
    public void PassInput ()
    {
        string password = _passField.text;
        // Code that uses the password variable.
    }
