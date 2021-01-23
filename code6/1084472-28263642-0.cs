    public void Keyword(string keyword) {
             if (keyword == "ShipUpgradeLeft") {
                 shipUpgradeSelected--;
                 if (shipUpgradeSelected < 0) {
                     shipUpgradeSelected = 0;
                     return;
                 }
     
                 ShipList[shipUpgradeSelected].SetActive(true);
                 if (shipUpgradeSelected + 1 < ShipList.Count) ShipList[shipUpgradeSelected + 1].SetActive(false);
                 else ShipList[0].SetActive(false);
             }
             if (keyword == "ShipUpgradeRight") {
                 shipUpgradeSelected++;
                 if (shipUpgradeSelected >= ShipList.Count) {
                     shipUpgradeSelected = ShipList.Count - 1;
                     return;
                 }
                 
                 ShipList[shipUpgradeSelected].SetActive(true);
                 if (shipUpgradeSelected > 0) ShipList[shipUpgradeSelected - 1].SetActive(false);
                 else ShipList[ShipList.Count-1].SetActive(false);
             }
         }
