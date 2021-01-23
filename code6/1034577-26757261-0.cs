    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using tesseract;
    using System.Drawing;
    using System.IO;
    
    public enum TesseractEngineMode : int
    {
        /// <summary>
        /// Run Tesseract only - fastest
        /// </summary>
        TESSERACT_ONLY = 0,
    
        /// <summary>
        /// Run Cube only - better accuracy, but slower
        /// </summary>
        CUBE_ONLY = 1,
    
        /// <summary>
        /// Run both and combine results - best accuracy
        /// </summary>
        TESSERACT_CUBE_COMBINED = 2,
    
        /// <summary>
        /// Specify this mode when calling init_*(),
        /// to indicate that any of the above modes
        /// should be automatically inferred from the
        /// variables in the language-specific config,
        /// command-line configs, or if not specified
        /// in any of the above should be set to the
        /// default OEM_TESSERACT_ONLY.
        /// </summary>
        DEFAULT = 3
    }
    
    public enum TesseractPageSegMode : int
    {
        /// <summary>
        /// Fully automatic page segmentation
        /// </summary>
        PSM_AUTO = 0,
    
        /// <summary>
        /// Assume a single column of text of variable sizes
        /// </summary>
        PSM_SINGLE_COLUMN = 1,
    
        /// <summary>
        /// Assume a single uniform block of text (Default)
        /// </summary>
        PSM_SINGLE_BLOCK = 2,
    
        /// <summary>
        /// Treat the image as a single text line
        /// </summary>
        PSM_SINGLE_LINE = 3,
    
        /// <summary>
        /// Treat the image as a single word
        /// </summary>
        PSM_SINGLE_WORD = 4,
    
        /// <summary>
        /// Treat the image as a single character
        /// </summary>
        PSM_SINGLE_CHAR = 5
    }
    
    public partial class importDLL : System.Web.UI.Page
    {
      
        private TesseractProcessor m_tesseract = null;
    
        //private const string m_path = @"..\..\data\";
        private const string m_path = @"D:\tessdata-3.02\";
        private const string m_lang = "eng";
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
          
    
            var image = System.Drawing.Image.FromFile(@"D:\Image\Capture1T.tif");
           
    
            m_tesseract = new TesseractProcessor();
            bool succeed = m_tesseract.Init(m_path, m_lang, (int)TesseractEngineMode.DEFAULT);
             if (!succeed)
             {
    
             }
    
            m_tesseract.SetVariable("tessedit_pageseg_mode", ((int)TesseractPageSegMode.PSM_SINGLE_LINE).ToString());
            m_tesseract.Clear();
            m_tesseract.ClearAdaptiveClassifier();
            string outValue= m_tesseract.Apply(image);
            Response.Write(outValue);
        }
    
      
    }
