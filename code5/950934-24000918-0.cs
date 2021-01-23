    public class ExportPoints : Exporter
    {
    private List<SldWorks.SketchPoint> listOfSketchPoints;
    public ExportPoints(SldWorks.SldWorks swApp) :
        base(swApp)
    {
         listOfSketchPoints  = new List<SldWorks.SketchPoint>();
    }
    public void createListOfFreePoints(string pointTest)
    {
        try
        {
            //imagine more code here
            listOfSketchPoints.Add(pointTest);
        }
        catch (Exception e)
        {
            Debug.Print(e.ToString());
            return;
        }
    }
