    public string[] createDir(string flow, int enclosure, string transaction, string method)
        {
            DateTime Hoy = DateTime.Now;
            libs.Catalogos objCatalogos = new libs.Catalogos();
            string day, month, year, hora, min, seg, time, ruta, fileName, name;
            string[] datos = new string[2];
            int existe;
            name = objCatalogos.convertRecinto(enclosure);
            day = System.DateTime.Now.ToString("dd");
            //day = "13";
            month = System.DateTime.Now.ToString("MM");
            year = System.DateTime.Now.ToString("yyyy");
            hora = System.DateTime.Now.ToString("HH");
            min = System.DateTime.Now.ToString("mm");
            seg = System.DateTime.Now.ToString("ss");
            time = hora + "_" + min + "_" + seg;
            ruta = @"C:\inetpub\wwwroot\WsDesarrollo2\" + @"XML" + @"\Empresa_" + name + @"\Flujo_" + flow + @"\Año_" + year + @"\Mes_" + month + @"\Dia_" + day + @"\";
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
        public void createXML<T>(string fileName, string route, T objeto)
        {
            System.Xml.Serialization.XmlSerializer serializador = new System.Xml.Serialization.XmlSerializer(typeof(T));
            TextWriter tw = new StreamWriter(@"" + route + @"\" + fileName + ".xml");
            serializador.Serialize(tw, objeto);
         }
