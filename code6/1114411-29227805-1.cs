	void Update () {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out hit)) {
          if (hit.collider.tag == "cube"){
            //Change color here
            }
        }else {
        // Change back to prvious color.
   }
}
