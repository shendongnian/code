    void OnGUI(){
        if (GUI.Button(new Rect(0, 0 , 10, 10), itemTexture,))
        {
            private Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            private Object block = Instantiate(objectYouClicked, new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0), Quaternion.identity);
        }
    }
