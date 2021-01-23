    public class _FFT_Obstacles : MonoBehaviour
    {
    	public FFTWindow window = FFTWindow.Hamming;
    
    	public GameObject cube01;
    	public GameObject cube02;
    	public GameObject cube03;
    	public GameObject cube04;
    	public GameObject cube05;
    
    	public float falloff = 3f;
    	public float juice = 40f;
    
    	public float[] spec;
    
    	public float specMag01;
    	public float specMag02;
    	public float specMag03;
    	public float specMag04;
    	public float specMag05;
    
    	private void Update()
    	{
    		spec = AudioListener.GetSpectrumData(64, 0, window); // this works on audio source
    		// spec = AudioListener.GetOutputData(64, 0);  // this gives much  better values.
    
    		specMag01 = spec[2] + spec[4];
    		specMag02 = spec[12] + spec[14];
    		specMag03 = spec[22] + spec[24];
    		specMag04 = spec[32] + spec[34];
    		specMag05 = spec[57] + spec[60];
    
    		UpdateCubeScale(cube01, specMag01);
    		UpdateCubeScale(cube02, specMag02);
    		UpdateCubeScale(cube03, specMag03);
    		UpdateCubeScale(cube04, specMag04);
    		UpdateCubeScale(cube05, specMag05);
    	}
    
    	private void UpdateCubeScale(GameObject cube, float specMag)
    	{
    		var currentScale = cube.transform.localScale;
    		var newScale = new Vector3(1f, 1f + (specMag * juice), 1f);
    
    		if (newScale.y < currentScale.y)
    		{
    			newScale.y = currentScale.y - falloff * Time.deltaTime;
    		}
    
    		if (newScale.y < 0f)
    		{
    			newScale.y = 0f;
    		}
    
    		cube.transform.localScale = newScale;
    	}
    }
