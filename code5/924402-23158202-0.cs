	[TestClass]
	public class DirTest {
	  public DirTest() { }
	  [TestMethod]
	  public void TestMethod1() {
	  }
	  [ClassInitialize]
	  public static void InitTest( TestContext context ) {
                if (!Directory.Exists( "testpath" )) {
                    Directory.CreateDirectory( "testpath" );
                }
	  }
	}
