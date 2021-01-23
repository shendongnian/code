    public class MyWizardControl : WizardControl {
        protected override WizardPainter CreatePainter() {
            return new MyWizardPainter();
        }
    }
    public class MyWizardPainter : WizardPainter {
        protected override WizardClientPainterBase CreateClientPainter(WizardViewInfo viewInfo) {
            return new MyWizardAeroClientPainter(viewInfo);
        }
    }
    public class MyWizardAeroClientPainter : WizardAeroClientPainter {
        public MyWizardAeroClientPainter(WizardViewInfo viewInfo) : base(viewInfo) { }
        protected override void DrawDividers(GraphicsInfoArgs e) {
            base.DrawDividers(e);
            int bottom = ViewInfo.GetContentBounds().Bottom;
            e.Graphics.DrawLine(Pens.White, ClientRect.Left, bottom, ClientRect.Right, bottom);
            e.Graphics.DrawLine(Pens.LightPink, ClientRect.Left, bottom + 1, ClientRect.Right, bottom + 1);
        }
    }
