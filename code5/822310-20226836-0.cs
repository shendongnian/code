    Component myComponent.MouseHover += new EventHandler(OnMouseHover);
    ...
    void OnMouseHover(object sender, EventArgs e)
    {
        Rect buttonRect = new Rect(250, Screen.height - buttonHeight, textInfoPlayerButtonWidth, textInfoPlayerButtonHeight);
        if (GameManager.instance.currentPlayerIndex == 0) (the object)
        {
            if (GUI.Button(buttonRect, "This is player 1"))
            {
                //accomplish whatever you had wanted here
            }
        }
    }
