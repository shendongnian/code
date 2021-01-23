        var v = Input.GetAxisRaw("JoyY1"); // Or "Vertical"
        if (Math.Abs(v) > ButtonThreashold)
        {
            var currentlySelected = EventSystem.currentSelectedGameObject
                ? EventSystem.currentSelectedGameObject.GetComponent<Selectable>()
                : FindObjectOfType<Selectable>();
            Selectable nextToSelect = null;
            if (v > ButtonThreashold)
            {
                nextToSelect = currentlySelected.FindSelectableOnUp();
            }
            else if (v < -ButtonThreashold)
            {
                nextToSelect = currentlySelected.FindSelectableOnDown();
            }
            if (nextToSelect)
            {
                EventSystem.SetSelectedGameObject(nextToSelect.gameObject);
            }
        }
