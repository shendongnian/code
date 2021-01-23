    public class MyView : Mobini.WebForms.ViewFamilyTree
    {
        protected internal override void Render(HtmlTextWriter writer)
        {
             writer.WriteLine("My view content header");
             writer.WriteLine(GetHelloWorlds_Protected());
             writer.WriteLine(GetHelloWorlds_Public());
             writer.WriteLine(GetHelloWorlds_Private());
             writer.WriteLine("My view content footer");
        }
    }
