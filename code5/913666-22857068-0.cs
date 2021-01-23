            using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsultingControls.highlight.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    RTBAuftragNEU.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
