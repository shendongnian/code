    public class PipetteScript : MonoBehaviour {
    public Animator pipetteAnim;
    public BoxCollider2D pipetteMove;
    public IndicatorScript indicator;
    public bool boolval = false;
    // Use this for initialization
    void Start () {
        pipetteAnim.enabled = true;
        pipetteMove.enabled = true;
        indicator.enabled = true;
    }
    void update()
    {
     if(boolval == true)
       pipetteAnim.Play ("Pipette_dropping");
     if(boolval == false)
       pipetteAnim.Stop ("Pipette_dropping");
    }
    void OnMouseDown () {
        boolval = True;
        }
    void OnMouseUp () {
        boolval = False;
        }
