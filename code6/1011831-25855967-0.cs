    public class Form {
        List<Panel> myPanels = new List<Panel>();
        public Form() {
              myPanels.Add(aPnl);
              myPanels.Add(bPnl);
              //etc
        }
        public TurnOffPanels(){
            foreach(var panel in myPanels){
                 panel.Enabled = false;
            }
        }
    }
