    bool RadioButton1Checked(){
        for(...){
            if (Math.Abs(miSdCrtica - _dMiSd) < 0.01)
            {
               //...
                racunskiAs1 = (_dMed * 1000) / (zeta * _dd * dFyd);
                break;
            }
            else if (_dMiSd < 0.086)
            {
                return false;
            }
        }
        return true;
    }
    void Button1_Click(...){
        if(radioButton1.Checked){
            if(!RadioButton1Checked()){ //if the function returns false
                //Display message box
                return;
            }
        }
        if(radioButton2.Checked){
            if(!SomeOtherFunction()){
                //Display message box
                return;
            }
        }
        ...
    }
