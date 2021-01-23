    public void RemoveUnitFromList(GameObject Unit) {
        if (SelectedUnitList.Count > 0) {
            for (int i = SelectedUnitList.Count -1; i >= 0; i--) {
                GameObject ArrayListUnit = SelectedUnitList[i] as GameObject;
                if (ArrayListUnit == Unit) {
                    SelectedUnitList.RemoveAt(i);
                    DeactivateProjectorOfObject(ArrayListUnit);
                }
            }
        }
    }
