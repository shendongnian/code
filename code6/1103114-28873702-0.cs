    using UnityEngine;
    using System.Collections;
    public class Tunge : MonoBehaviour {
    
    int x = 0;
    bool vis = false;
    public GameObject tungen;
    
    public Animator doge;
    
    
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update () {
    Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
    Vector3 dir = Input.mousePosition - pos;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    doge.SetFloat ("tungelength", x);
    if (vis == true) 
    {
        tungen.SetActive(true);
    }
    if (vis == false) 
    {
        tungen.SetActive(false);
    }
    if (Input.GetMouseButton(0)) 
    {
        vis = true;
        float flyt = 0.1f;
        tungen.transform.localScale += new Vector3 (0, flyt, 0);
        // ADD THIS LINE:
        tungen.transform.position += new Vector3( 0, flyt / 2, 0 );
        x++;
    }
    if (!Input.GetMouseButton (0) && x > 0) 
    {
        float flyt = 0.1f;
        tungen.transform.localScale += new Vector3 (0, -flyt, 0);
        // ADD THIS LINE:
        tungen.transform.position += new Vector3( 0, -flyt / 2, 0 );
        x--;
    }
    if (x == 0) 
    {
        vis = false;         
    }
}
}
