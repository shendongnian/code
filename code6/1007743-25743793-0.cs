    public class Wrapper
    {
        RadioNetwork m_r;
        public Wrapper(RadioNetwork r) { m_r=r; }
        public object NetworkIdentifier { get { return m_r.NetworkIdentifier; }}
        public string Text { get { return m_r.RepeaterName.ToString()+"-"+m_r.startCode; }}
    }
    ...
    return new SelectList(db.RadioNetworks.OrderBy(x => x.RepeaterName).Select(x=>new Wrapper(x)), "NetworkIdentifier", "Text");
