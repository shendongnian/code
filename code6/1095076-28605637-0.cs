    using Visio = Microsoft.Office.Interop.Visio;
    var visio = (Visio.Application) System.Runtime.InteropServices.Marshal.GetActiveObject("Visio.Application");
    var vsd = visio.ActiveDocument;
    foreach(Visio.Shape shape in vsd.Pages[1].Shapes) {
      foreach(Visio.Document stencil in visio.Documents) {
        if (stencil.Type == Visio.VisDocumentTypes.visTypeStencil) {
          foreach(Visio.Master sh in stencil.Masters) {
            if (sh.Name == shape.Name) {
              Console.WriteLine(stencil.Name);
              break;
            }
          }
        }
      }
    }
