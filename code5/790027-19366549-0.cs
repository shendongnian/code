    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Net.Mail;
    namespace Grupo_Zulcon
    {
    public partial class EnvianosTuCurriculum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Botones botones = new Botones();
            botones.SaveCVInfo2(nombre.Text, Apellidos.Text, EmpleoS.Text, DireccionPersonal.Text, RadioButtonList6.SelectedItem.Text);
        }
    }
    }
