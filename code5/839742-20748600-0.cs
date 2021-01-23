    public class xmlLog
    {
        public int verifyDir(string dir)
        {
            bool tryDir;
            tryDir = Directory.Exists(dir);
            if (tryDir == false)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string[] createDir(string flow, int enclosure, string transaction, string method)
        {
            DateTime Hoy = DateTime.Now;
            libs.Catalogos objCatalogos = new libs.Catalogos();
            string day, month, year, hora, min, seg, time, ruta, fileName, name;
            string[] datos = new string[2];
            int existe;
            name = objCatalogos.convertRecinto(enclosure);
            day = System.DateTime.Now.ToString("dd");
            month = System.DateTime.Now.ToString("MM");
            year = System.DateTime.Now.ToString("yyyy");
            hora = System.DateTime.Now.ToString("HH");
            min = System.DateTime.Now.ToString("mm");
            seg = System.DateTime.Now.ToString("ss");
            time = hora + "_" + min + "_" + seg;
            ruta = @"C:\inetpub\wwwroot\WsDesarrollo\" + @"XML" + @"\Empresa_" + name + @"\Flujo_" + flow + @"\Año_" + year + @"\Mes_" + month + @"\Dia_" + day + @"\";
            existe = verifyDir(ruta);
            if (existe == 0)
            {
                Directory.CreateDirectory(ruta);
            }
            fileName = "" + ruta + transaction + "_" + method + "_" + time;
            datos[0] = ruta;
            datos[1] = fileName;
            return datos;
        }
        public void createXML<T>(string route, string fileName, T objeto)
        {
            string file = Path.Combine(route, fileName + ".xml");
            System.Xml.Serialization.XmlSerializer slzr = new System.Xml.Serialization.XmlSerializer(typeof(T));
            TextWriter tw = new StreamWriter(file);
            slzr.Serialize(tw, objeto);
        }
    }
