    class Program {
        static void Main(string[] args) {
            var xmlstr = 
    @"<a att='1'>
        <b attb='a b c'>
          <c att2='text'>value</c>
        </b>
    </a>";
            dynamic xml = new DynamicXml(xmlstr);
            Console.WriteLine(xml.a[0].att);
            Console.WriteLine(xml.a[0].b[0].attb);
            Console.WriteLine(xml.a[0].b[0].c[0].att2);
            }
        public class DynamicXml: DynamicObject {
            XElement _root;
            IEnumerable<XElement> _xele;
            public DynamicXml(string xml) {
                var xdoc = XDocument.Parse(xml);
                _root = xdoc.Root;
                }
            DynamicXml(XElement root) {
                _root = root;
                }
            DynamicXml(XElement root, IEnumerable<XElement> xele) {
                _root = root;
                _xele = xele;
                }
            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
                // you should check binder.CallInfo, but for the example I'm assuming [n] where n is int type indexing
                var idx = (int)indexes[0];
                result = new DynamicXml(_xele.ElementAt(idx));
                return true;
                }
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                var atr = _root.Attributes(binder.Name).FirstOrDefault();
                if (atr != null) {
                    result = atr.Value;
                    return true;
                    }
                var ele = _root.DescendantsAndSelf(binder.Name);
                if (ele != null) {
                    result = new DynamicXml(_root, ele);
                    return true;
                    }
                result = null;
                return false;
                }
            }
        }
