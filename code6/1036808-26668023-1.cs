	public partial class Form1
	{
		public MachineClass machineObj = new MachineClass();
	
		public void Form1_Load()
		{
			this.machineObj.FruitUpdate1 += v => label1.ImageIndex = v;
			this.machineObj.FruitUpdate2 += v => label2.ImageIndex = v;
			this.machineObj.FruitUpdate3 += v => label3.ImageIndex = v;
		}
		
		public class MachineClass
		{
			/* definition from above */
		}
	}
