    partial class Examples
    {
        public static Rhino.Commands.Result AddLayer(Rhino.RhinoDoc doc)
        {
            // <snip>
            layer_index = doc.Layers.Add(layer_name, System.Drawing.Color.Black);
            // <snip>
        }
    }
