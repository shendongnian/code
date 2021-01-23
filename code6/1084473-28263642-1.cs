    private void Start()
     {
         ShipUpgradeLeft.GetComponent<Button>().onClick.AddListener(() => { Previous(); });
         ShipUpgradeRight.GetComponent<Button>().onClick.AddListener(() => { Next(); });
     }
     public void Next()
     {
         ShipList[shipUpgradeSelected].SetActive(false);
         shipUpgradeSelected = Mathf.Clamp(shipUpgradeSelected++, 0, ShipList.Count - 1);
         ShipList[shipUpgradeSelected].SetActive(true);
     }
     public void Previous()
     {
         ShipList[shipUpgradeSelected].SetActive(false);
         shipUpgradeSelected = Mathf.Clamp(shipUpgradeSelected--, 0, ShipList.Count - 1);
         ShipList[shipUpgradeSelected].SetActive(true);
     }
