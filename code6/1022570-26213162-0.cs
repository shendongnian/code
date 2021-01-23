    public partial class Form1 : XtraForm {
        static Form1() {
            SkinManager.EnableFormSkins();
        }
        public Form1() {
            InitializeComponent();
        }
        protected override FormPainter CreateFormBorderPainter() {
            return new CustomFormPainter(this, LookAndFeel);
        }
    }
    public class CustomFormPainter : FormPainter {
        public CustomFormPainter(Control owner, DevExpress.Skins.ISkinProvider provider)
            : base(owner, provider) {
        }
        protected override void DrawText(DevExpress.Utils.Drawing.GraphicsCache cache) {
            string text = Text;
            if(text == null || text.Length == 0 || TextBounds.IsEmpty) return;
            using(AppearanceObject appearance = new AppearanceObject(GetDefaultAppearance())) {
                appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
                appearance.TextOptions.HAlignment = HorzAlignment.Center;
                if(AllowHtmlDraw) {
                    DrawHtmlText(cache, appearance);
                    return;
                }
                Rectangle r = RectangleHelper.GetCenterBounds(TextBounds, new Size(TextBounds.Width, CalcTextHeight(cache.Graphics, appearance)));
                DrawTextShadow(cache, appearance, r);
                cache.DrawString(text, appearance.Font, appearance.GetForeBrush(cache), r, appearance.GetStringFormat());
            }
        }
    }
