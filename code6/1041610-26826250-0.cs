    bool ValidateAll(){
        bool isNum = int.TryParse(textBox5.Text.Trim(), out num);
        if (!isNum)
        {
            return false; 
        }
        isNum = int.TryParse(textBox6.Text.Trim(), out num);
        if (!isNum)
        {
            return false;
        }
        return true;
    }
