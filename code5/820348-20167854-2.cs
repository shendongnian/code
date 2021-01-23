    public static float textHeight = 25;
    public static float textWidth = 1350;
    public static float buttonHeight = 25;
    public static float buttonWidth = 100;
    public static float screenTextHeight = 745;
    
    bool move=false,attack=false,endTurn=false;  //Added
    
    public virtual void TurnOnGUI()
    {
    	Rect buttonRect = new Rect(0, Screen.height - buttonHeight * 3, buttonWidth, buttonHeight);
    	Rect tooltipRect = new Rect(100 + 10, Screen.height - buttonHeight * 3 + 5, buttonWidth, buttonHeight);
    	Rect textRect = new Rect(10, Screen.height - screenTextHeight, textWidth, textHeight);
    	Rect _buttonRect = new Rect(0, Screen.height - buttonHeight * 2, buttonWidth, buttonHeight);
    	Rect _buttonRect_ = new Rect(0, Screen.height - buttonHeight * 1, buttonWidth, buttonHeight);
    	Rect _tooltipRect = new Rect(100 + 10, Screen.height - buttonHeight * 2 + 5, buttonWidth, buttonHeight);
    	Rect _tooltipRect_ = new Rect(100 + 10, Screen.height - buttonHeight * 1 + 5, buttonWidth, buttonHeight);
    	
    	label1.normal.textColor = Color.red;
    	
    	//Text Field
    	if (GUI.Button(textRect, ""))
    	{
    
    	}
    	
    	//ToolTip Text
    	move = GUI.Button(buttonRect, new GUIContent("Move", "Move the Player"));
    	GUI.Label(tooltipRect, GUI.tooltip, label1);
    	
    	GUI.tooltip = null;
    	//Move Button
    	if (move)   //edited
    	{
    		if (!moving)
    		{
    			GameManager.instance.RemoveTileHighlights();
    			moving = true;
    			attacking = false;
    			GameManager.instance.HighlightTilesAt(gridPosition, Color.blue, movementPerActionPoint);
    		}
    		
    		else
    		{
    			moving = false;
    			attacking = false;
    			GameManager.instance.RemoveTileHighlights();
    		}
    	}
    	
    	//ToolTip Text
    	attack = GUI.Button(_buttonRect, new GUIContent("Attack", "Attack the Player"));
    	GUI.Label(_tooltipRect, GUI.tooltip, label1);
    	
    	GUI.tooltip = null;
    	//Attack Button
    	if (attack)   //edited
    	{
    		if (!attacking)
    		{
    			GameManager.instance.RemoveTileHighlights();
    			moving = false;
    			attacking = true;
    			GameManager.instance.HighlightTilesAt(gridPosition, Color.red, attackRange);
    		}
    		
    		else
    		{
    			moving = false;
    			attacking = false;
    			GameManager.instance.RemoveTileHighlights();
    		}
    	}
    	
    	//ToolTip Text
    	endTurn = GUI.Button(_buttonRect_, new GUIContent("End Turn", "End Turn the Player"));
    	GUI.Label(_tooltipRect_, GUI.tooltip, label1);
    	
    	GUI.tooltip = null;
    	//End Turn Button
    	if (endTurn)   //edited
    	{
    		GameManager.instance.RemoveTileHighlights();
    		actionPoints = 2;
    		moving = false;
    		attacking = false;
    		GameManager.instance.NextTurn();
    	}
    }
