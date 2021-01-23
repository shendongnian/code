    public class BorderPhoto{
		IPhoto pho;
		Color color;
		
		public BorderPhoto(IPhoto p, Color c)
		{
			pho = p;
			color = c;
			this.addPaintEventhandler(new IPhoto(){
				public void Drawer(object sender, ...other parameters...){
					// put your code here
				}
			});	
		}
		
		public void addPaintEventHandler(Iphoto pho){
			this.pho = pho;
		}
		
		public void onDraw(this, ...other parameters...){
			pho.Drawer(this, ...other parameters...);
		}
	}
