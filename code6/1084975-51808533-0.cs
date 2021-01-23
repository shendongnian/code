    using UnityEngine.UI;
    public InputField betInput;
    void Start () {
        betInput.onEndEdit.AddListener(delegate { inputBetValue(betInput); });
    }
    public void inputBetValue(InputField userInput)
    {
        betValue = int.Parse(userInput.text);
        Debug.Log(userInput.text);
    }
