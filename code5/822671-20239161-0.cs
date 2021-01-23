[XmlRoot]
public class Changelog
{
    private List<Release> releases;
    public List<Release> Releases
    {
        get { return releases; }
        set { releases = value; }
    }
}
public class Release
{
    private string version;
    private string date;
    private List<ChangeItem> changes;
    [XmlElement]
    public string Version
    {
        get { return version; }
        set { version = value; }
    }
    [XmlElement]
    public string Date
    {
        get { return date; }
        set { date = value; }
    }
    <strong>[XmlArray("Changes")]
    [XmlArrayItem("Change")]</strong>
    public List<ChangeItem> Changes
    {
        get { return changes; }
        set { changes = value; }
    }
}
public class ChangeItem
{
    private string change;
    <strong>[XmlText]</strong>
    public string Change
    {
        get { return change; }
        set { change = value; }
    }
}
