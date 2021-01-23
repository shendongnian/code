	using Microsoft.VisualBasic;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Runtime.InteropServices;
	public class Form1
	{
		private void Form1_Load(System.Object sender, System.EventArgs e)
		{
			//'//Create our helper function
			UnicodeCharRanges UCR = new UnicodeCharRanges();
			//'//Get our ranges for ja-JP
			object Ranges = UCR.GetUnicodeRanges("ja-JP");
			if (Ranges != null) {
				//'//Get our characters (strings actually)
				object Chars = UCR.GetCharactersForUnicodeRanges(Ranges);
				Trace.WriteLine(Chars.Count);
				//'//28351
				//'//Include surrogate pairs as letters. .Net does not have a way to determine if these should be considered letters
				Chars = UCR.GetCharactersForUnicodeRanges(Ranges, true);
				Trace.WriteLine(Chars.Count);
				//'//71615
			}
			//'//Get our ranges for en-US
			Ranges = UCR.GetUnicodeRanges("en-US");
			if (Ranges != null) {
				//'//Get our characters (strings actually)
				object Chars = UCR.GetCharactersForUnicodeRanges(Ranges);
				Trace.WriteLine(Chars.Count);
				//'//117
			}
		}
		public Form1()
		{
			Load += Form1_Load;
		}
	}
	public class UnicodeCharRanges
	{
		#region " Unmanaged "
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern int GetLocaleInfoW(int locale, int LCType, ref LOCALESIGNATURE lpLCData, int cchData);
		private int LOCALE_FONTSIGNATURE = 0x58;
		[StructLayout(LayoutKind.Sequential)]
		private struct LOCALESIGNATURE
		{
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 4)]
			public int[] lsUsb;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2)]
			public int[] lsCsbDefault;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2)]
			public int[] lsCsbSupported;
			public void Initialize()
			{
				lsUsb = new int[4];
				lsCsbDefault = new int[2];
				lsCsbSupported = new int[2];
			}
		}
		#endregion
		#region " Locals "
			#endregion
		private List<UnicodeRangeInfo> AllRanges;
		private void LoadRanges()
		{
			//'//Ranges from http://msdn.microsoft.com/en-us/library/dd374090%28VS.85%29.aspx
			AllRanges = new List<UnicodeRangeInfo>();
			AllRanges.Add(new UnicodeRangeInfo(0, 0x0, 0x7f, "Basic Latin"));
			AllRanges.Add(new UnicodeRangeInfo(1, 0x80, 0xff, "Latin-1 Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(2, 0x100, 0x17f, "Latin Extended-A"));
			AllRanges.Add(new UnicodeRangeInfo(3, 0x180, 0x24f, "Latin Extended-B"));
			AllRanges.Add(new UnicodeRangeInfo(4, 0x250, 0x2af, "IPA Extensions"));
			AllRanges.Add(new UnicodeRangeInfo(4, 0x1d00, 0x1d7f, "Phonetic Extensions"));
			AllRanges.Add(new UnicodeRangeInfo(4, 0x1d80, 0x1dbf, "Phonetic Extensions Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(5, 0x2b0, 0x2ff, "Spacing Modifier Letters"));
			AllRanges.Add(new UnicodeRangeInfo(5, 0xa700, 0xa71f, "Modifier Tone Letters"));
			AllRanges.Add(new UnicodeRangeInfo(6, 0x300, 0x36f, "Combining Diacritical Marks"));
			AllRanges.Add(new UnicodeRangeInfo(6, 0x1dc0, 0x1dff, "Combining Diacritical Marks Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(7, 0x370, 0x3ff, "Greek and Coptic"));
			AllRanges.Add(new UnicodeRangeInfo(8, 0x2c80, 0x2cff, "Coptic"));
			AllRanges.Add(new UnicodeRangeInfo(9, 0x400, 0x4ff, "Cyrillic"));
			AllRanges.Add(new UnicodeRangeInfo(9, 0x500, 0x52f, "Cyrillic Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(9, 0x2de0, 0x2dff, "Cyrillic Extended-A"));
			AllRanges.Add(new UnicodeRangeInfo(9, 0xa640, 0xa69f, "Cyrillic Extended-B"));
			AllRanges.Add(new UnicodeRangeInfo(10, 0x530, 0x58f, "Armenian"));
			AllRanges.Add(new UnicodeRangeInfo(11, 0x590, 0x5ff, "Hebrew"));
			AllRanges.Add(new UnicodeRangeInfo(12, 0xa500, 0xa63f, "&hVai"));
			AllRanges.Add(new UnicodeRangeInfo(13, 0x600, 0x6ff, "Arabic"));
			AllRanges.Add(new UnicodeRangeInfo(13, 0x750, 0x77f, "Arabic Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(14, 0x7c0, 0x7ff, "NKo"));
			AllRanges.Add(new UnicodeRangeInfo(15, 0x900, 0x97f, "Devanagari"));
			AllRanges.Add(new UnicodeRangeInfo(16, 0x980, 0x9ff, "Bengali"));
			AllRanges.Add(new UnicodeRangeInfo(17, 0xa00, 0xa7f, "Gurmukhi"));
			AllRanges.Add(new UnicodeRangeInfo(18, 0xa80, 0xaff, "Gujarati"));
			AllRanges.Add(new UnicodeRangeInfo(19, 0xb00, 0xb7f, "Oriya"));
			AllRanges.Add(new UnicodeRangeInfo(20, 0xb80, 0xbff, "Tamil"));
			AllRanges.Add(new UnicodeRangeInfo(21, 0xc00, 0xc7f, "Telugu"));
			AllRanges.Add(new UnicodeRangeInfo(22, 0xc80, 0xcff, "Kannada"));
			AllRanges.Add(new UnicodeRangeInfo(23, 0xd00, 0xd7f, "Malayalam"));
			AllRanges.Add(new UnicodeRangeInfo(24, 0xe00, 0xe7f, "Thai"));
			AllRanges.Add(new UnicodeRangeInfo(25, 0xe80, 0xeff, "Lao"));
			AllRanges.Add(new UnicodeRangeInfo(26, 0x10a0, 0x10ff, "Georgian"));
			AllRanges.Add(new UnicodeRangeInfo(26, 0x2d00, 0x2d2f, "Georgian Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(27, 0x1b00, 0x1b7f, "Balinese"));
			AllRanges.Add(new UnicodeRangeInfo(28, 0x1100, 0x11ff, "Hangul Jamo"));
			AllRanges.Add(new UnicodeRangeInfo(29, 0x1e00, 0x1eff, "Latin Extended Additional"));
			AllRanges.Add(new UnicodeRangeInfo(29, 0x2c60, 0x2c7f, "Latin Extended-C"));
			AllRanges.Add(new UnicodeRangeInfo(29, 0xa720, 0xa7ff, "Latin Extended-D"));
			AllRanges.Add(new UnicodeRangeInfo(30, 0x1f00, 0x1fff, "Greek Extended"));
			AllRanges.Add(new UnicodeRangeInfo(31, 0x2000, 0x206f, "General Punctuation"));
			AllRanges.Add(new UnicodeRangeInfo(31, 0x2e00, 0x2e7f, "Supplemental Punctuation"));
			AllRanges.Add(new UnicodeRangeInfo(32, 0x2070, 0x209f, "Superscripts And Subscripts"));
			AllRanges.Add(new UnicodeRangeInfo(33, 0x20a0, 0x20cf, "Currency Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(34, 0x20d0, 0x20ff, "Combining Diacritical Marks For Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(35, 0x2100, 0x214f, "Letterlike Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(36, 0x2150, 0x218f, "Number Forms"));
			AllRanges.Add(new UnicodeRangeInfo(37, 0x2190, 0x21ff, "Arrows"));
			AllRanges.Add(new UnicodeRangeInfo(37, 0x27f0, 0x27ff, "Supplemental Arrows-A"));
			AllRanges.Add(new UnicodeRangeInfo(37, 0x2900, 0x297f, "Supplemental Arrows-B"));
			AllRanges.Add(new UnicodeRangeInfo(37, 0x2b00, 0x2bff, "Miscellaneous Symbols and Arrows"));
			AllRanges.Add(new UnicodeRangeInfo(38, 0x2200, 0x22ff, "Mathematical Operators"));
			AllRanges.Add(new UnicodeRangeInfo(38, 0x27c0, 0x27ef, "Miscellaneous Mathematical Symbols-A"));
			AllRanges.Add(new UnicodeRangeInfo(38, 0x2980, 0x29ff, "Miscellaneous Mathematical Symbols-B"));
			AllRanges.Add(new UnicodeRangeInfo(38, 0x2a00, 0x2aff, "Supplemental Mathematical Operators"));
			AllRanges.Add(new UnicodeRangeInfo(39, 0x2300, 0x23ff, "Miscellaneous Technical"));
			AllRanges.Add(new UnicodeRangeInfo(40, 0x2400, 0x243f, "Control Pictures"));
			AllRanges.Add(new UnicodeRangeInfo(41, 0x2440, 0x245f, "Optical Character Recognition"));
			AllRanges.Add(new UnicodeRangeInfo(42, 0x2460, 0x24ff, "Enclosed Alphanumerics"));
			AllRanges.Add(new UnicodeRangeInfo(43, 0x2500, 0x257f, "Box Drawing"));
			AllRanges.Add(new UnicodeRangeInfo(44, 0x2580, 0x259f, "Block Elements"));
			AllRanges.Add(new UnicodeRangeInfo(45, 0x25a0, 0x25ff, "Geometric Shapes"));
			AllRanges.Add(new UnicodeRangeInfo(46, 0x2600, 0x26ff, "Miscellaneous Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(47, 0x2700, 0x27bf, "Dingbats"));
			AllRanges.Add(new UnicodeRangeInfo(48, 0x3000, 0x303f, "CJK Symbols And Punctuation"));
			AllRanges.Add(new UnicodeRangeInfo(49, 0x3040, 0x309f, "Hiragana"));
			AllRanges.Add(new UnicodeRangeInfo(50, 0x30a0, 0x30ff, "Katakana"));
			AllRanges.Add(new UnicodeRangeInfo(50, 0x31f0, 0x31ff, "Katakana Phonetic Extensions"));
			AllRanges.Add(new UnicodeRangeInfo(51, 0x3100, 0x312f, "Bopomofo"));
			AllRanges.Add(new UnicodeRangeInfo(51, 0x31a0, 0x31bf, "Bopomofo Extended"));
			AllRanges.Add(new UnicodeRangeInfo(52, 0x3130, 0x318f, "Hangul Compatibility Jamo"));
			AllRanges.Add(new UnicodeRangeInfo(53, 0xa840, 0xa87f, "Phags-pa"));
			AllRanges.Add(new UnicodeRangeInfo(54, 0x3200, 0x32ff, "Enclosed CJK Letters And Months"));
			AllRanges.Add(new UnicodeRangeInfo(55, 0x3300, 0x33ff, "CJK Compatibility"));
			AllRanges.Add(new UnicodeRangeInfo(56, 0xac00, 0xd7af, "Hangul Syllables"));
			AllRanges.Add(new UnicodeRangeInfo(57, 0xd800, 0xdfff, "Non-Plane 0. Note that setting this bit implies that there is at least one supplementary code point beyond the Basic Multilingual Plane (BMP) that is supported by this font. See Surrogates and Supplementary Characters."));
			AllRanges.Add(new UnicodeRangeInfo(58, 0x10900, 0x1091f, "Phoenician"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x2e80, 0x2eff, "CJK Radicals Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x2f00, 0x2fdf, "Kangxi Radicals"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x2ff0, 0x2fff, "Ideographic Description Characters"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x3190, 0x319f, "Kanbun"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x3400, 0x4dbf, "CJK Unified Ideographs Extension A"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x4e00, 0x9fff, "CJK Unified Ideographs"));
			AllRanges.Add(new UnicodeRangeInfo(59, 0x20000, 0x2a6df, "CJK Unified Ideographs Extension B"));
			AllRanges.Add(new UnicodeRangeInfo(60, 0xe000, 0xf8ff, "Private Use Area"));
			AllRanges.Add(new UnicodeRangeInfo(61, 0x31c0, 0x31ef, "CJK Strokes"));
			AllRanges.Add(new UnicodeRangeInfo(61, 0xf900, 0xfaff, "CJK Compatibility Ideographs"));
			AllRanges.Add(new UnicodeRangeInfo(61, 0x2f800, 0x2fa1f, "CJK Compatibility Ideographs Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(62, 0xfb00, 0xfb4f, "Alphabetic Presentation Forms"));
			AllRanges.Add(new UnicodeRangeInfo(63, 0xfb50, 0xfdff, "Arabic Presentation Forms-A"));
			AllRanges.Add(new UnicodeRangeInfo(64, 0xfe20, 0xfe2f, "Combining Half Marks"));
			AllRanges.Add(new UnicodeRangeInfo(65, 0xfe10, 0xfe1f, "Vertical Forms"));
			AllRanges.Add(new UnicodeRangeInfo(65, 0xfe30, 0xfe4f, "CJK Compatibility Forms"));
			AllRanges.Add(new UnicodeRangeInfo(66, 0xfe50, 0xfe6f, "Small Form Variants"));
			AllRanges.Add(new UnicodeRangeInfo(67, 0xfe70, 0xfeff, "Arabic Presentation Forms-B"));
			AllRanges.Add(new UnicodeRangeInfo(68, 0xff00, 0xffef, "Halfwidth And Fullwidth Forms"));
			AllRanges.Add(new UnicodeRangeInfo(69, 0xfff0, 0xffff, "Specials"));
			AllRanges.Add(new UnicodeRangeInfo(70, 0xf00, 0xfff, "Tibetan"));
			AllRanges.Add(new UnicodeRangeInfo(71, 0x700, 0x74f, "Syriac"));
			AllRanges.Add(new UnicodeRangeInfo(72, 0x780, 0x7bf, "Thaana"));
			AllRanges.Add(new UnicodeRangeInfo(73, 0xd80, 0xdff, "Sinhala"));
			AllRanges.Add(new UnicodeRangeInfo(74, 0x1000, 0x109f, "Myanmar"));
			AllRanges.Add(new UnicodeRangeInfo(75, 0x1200, 0x137f, "Ethiopic"));
			AllRanges.Add(new UnicodeRangeInfo(75, 0x1380, 0x139f, "Ethiopic Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(75, 0x2d80, 0x2ddf, "Ethiopic Extended"));
			AllRanges.Add(new UnicodeRangeInfo(76, 0x13a0, 0x13ff, "Cherokee"));
			AllRanges.Add(new UnicodeRangeInfo(77, 0x1400, 0x167f, "Unified Canadian Aboriginal Syllabics"));
			AllRanges.Add(new UnicodeRangeInfo(78, 0x1680, 0x169f, "Ogham"));
			AllRanges.Add(new UnicodeRangeInfo(79, 0x16a0, 0x16ff, "Runic"));
			AllRanges.Add(new UnicodeRangeInfo(80, 0x1780, 0x17ff, "Khmer"));
			AllRanges.Add(new UnicodeRangeInfo(80, 0x19e0, 0x19ff, "Khmer Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(81, 0x1800, 0x18af, "Mongolian"));
			AllRanges.Add(new UnicodeRangeInfo(82, 0x2800, 0x28ff, "Braille Patterns"));
			AllRanges.Add(new UnicodeRangeInfo(83, 0xa000, 0xa48f, "Yi Syllables"));
			AllRanges.Add(new UnicodeRangeInfo(83, 0xa490, 0xa4cf, "Yi Radicals"));
			AllRanges.Add(new UnicodeRangeInfo(84, 0x1700, 0x171f, "Tagalog"));
			AllRanges.Add(new UnicodeRangeInfo(84, 0x1720, 0x173f, "Hanunoo"));
			AllRanges.Add(new UnicodeRangeInfo(84, 0x1740, 0x175f, "Buhid"));
			AllRanges.Add(new UnicodeRangeInfo(84, 0x1760, 0x177f, "Tagbanwa"));
			AllRanges.Add(new UnicodeRangeInfo(85, 0x10300, 0x1032f, "Old Italic"));
			AllRanges.Add(new UnicodeRangeInfo(86, 0x10330, 0x1034f, "Gothic"));
			AllRanges.Add(new UnicodeRangeInfo(87, 0x10400, 0x1044f, "Deseret"));
			AllRanges.Add(new UnicodeRangeInfo(88, 0x1d000, 0x1d0ff, "Byzantine Musical Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(88, 0x1d100, 0x1d1ff, "Musical Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(88, 0x1d200, 0x1d24f, "Ancient Greek Musical Notation"));
			AllRanges.Add(new UnicodeRangeInfo(89, 0x1d400, 0x1d7ff, "Mathematical Alphanumeric Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(90, 0xff000, 0xffffd, "Private Use (plane 15)"));
			AllRanges.Add(new UnicodeRangeInfo(90, 0x100000, 0x10fffd, "Private Use (plane 16)"));
			AllRanges.Add(new UnicodeRangeInfo(91, 0xfe00, 0xfe0f, "Variation Selectors"));
			AllRanges.Add(new UnicodeRangeInfo(91, 0xe0100, 0xe01ef, "Variation Selectors Supplement"));
			AllRanges.Add(new UnicodeRangeInfo(92, 0xe0000, 0xe007f, "Tags"));
			AllRanges.Add(new UnicodeRangeInfo(93, 0x1900, 0x194f, "Limbu"));
			AllRanges.Add(new UnicodeRangeInfo(94, 0x1950, 0x197f, "Tai Le"));
			AllRanges.Add(new UnicodeRangeInfo(95, 0x1980, 0x19df, "New Tai Lue"));
			AllRanges.Add(new UnicodeRangeInfo(96, 0x1a00, 0x1a1f, "Buginese"));
			AllRanges.Add(new UnicodeRangeInfo(97, 0x2c00, 0x2c5f, "Glagolitic"));
			AllRanges.Add(new UnicodeRangeInfo(98, 0x2d30, 0x2d7f, "Tifinagh"));
			AllRanges.Add(new UnicodeRangeInfo(99, 0x4dc0, 0x4dff, "Yijing Hexagram Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(100, 0xa800, 0xa82f, "Syloti Nagri"));
			AllRanges.Add(new UnicodeRangeInfo(101, 0x10000, 0x1007f, "Linear B Syllabary"));
			AllRanges.Add(new UnicodeRangeInfo(101, 0x10080, 0x100ff, "Linear B Ideograms"));
			AllRanges.Add(new UnicodeRangeInfo(101, 0x10100, 0x1013f, "Aegean Numbers"));
			AllRanges.Add(new UnicodeRangeInfo(102, 0x10140, 0x1018f, "Ancient Greek Numbers"));
			AllRanges.Add(new UnicodeRangeInfo(103, 0x10380, 0x1039f, "Ugaritic"));
			AllRanges.Add(new UnicodeRangeInfo(104, 0x103a0, 0x103df, "Old Persian"));
			AllRanges.Add(new UnicodeRangeInfo(105, 0x10450, 0x1047f, "Shavian"));
			AllRanges.Add(new UnicodeRangeInfo(106, 0x10480, 0x104af, "Osmanya"));
			AllRanges.Add(new UnicodeRangeInfo(107, 0x10800, 0x1083f, "Cypriot Syllabary"));
			AllRanges.Add(new UnicodeRangeInfo(108, 0x10a00, 0x10a5f, "Kharoshthi"));
			AllRanges.Add(new UnicodeRangeInfo(109, 0x1d300, 0x1d35f, "Tai Xuan Jing Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(110, 0x12000, 0x123ff, "Cuneiform"));
			AllRanges.Add(new UnicodeRangeInfo(110, 0x12400, 0x1247f, "Cuneiform Numbers and Punctuation"));
			AllRanges.Add(new UnicodeRangeInfo(111, 0x1d360, 0x1d37f, "Counting Rod Numerals"));
			AllRanges.Add(new UnicodeRangeInfo(112, 0x1b80, 0x1bbf, "Sundanese"));
			AllRanges.Add(new UnicodeRangeInfo(113, 0x1c00, 0x1c4f, "Lepcha"));
			AllRanges.Add(new UnicodeRangeInfo(114, 0x1c50, 0x1c7f, "Ol Chiki"));
			AllRanges.Add(new UnicodeRangeInfo(115, 0xa880, 0xa8df, "Saurashtra"));
			AllRanges.Add(new UnicodeRangeInfo(116, 0xa900, 0xa92f, "Kayah Li"));
			AllRanges.Add(new UnicodeRangeInfo(117, 0xa930, 0xa95f, "Rejang"));
			AllRanges.Add(new UnicodeRangeInfo(118, 0xaa00, 0xaa5f, "Cham"));
			AllRanges.Add(new UnicodeRangeInfo(119, 0x10190, 0x101cf, "hAncient Symbols"));
			AllRanges.Add(new UnicodeRangeInfo(120, 0x101d0, 0x101ff, "Phaistos Disc"));
			AllRanges.Add(new UnicodeRangeInfo(121, 0x10280, 0x1029f, "Lycian"));
			AllRanges.Add(new UnicodeRangeInfo(121, 0x102a0, 0x102df, "Carian"));
			AllRanges.Add(new UnicodeRangeInfo(121, 0x10920, 0x1093f, "Lydian"));
			AllRanges.Add(new UnicodeRangeInfo(122, 0x1f000, 0x1f02f, "Mahjong Tiles"));
			AllRanges.Add(new UnicodeRangeInfo(122, 0x1f030, 0x1f09f, "Domino Tiles"));
		}
		public UnicodeCharRanges()
		{
			LoadRanges();
		}
		public List<string> GetCharactersForUnicodeRanges(List<UnicodeRangeInfo> ranges, bool returnSurrogatePairs = false)
		{
			//'//The Char structure cannot represent all Unicode characters so we need to return strings. See "Surrogate pairs" at the bottom of http://www.yoda.arachsys.com/csharp/unicode.html
			List<string> Ret = new List<string>();
			string S = null;
			char C = '\0';
			//'//Loop through all of the ranges
			foreach (void R_loopVariable in ranges) {
				R = R_loopVariable;
				//'//Loop from start to end
				for (I = R.StartRange; I <= R.EndRange; I++) {
					//'//Convert the integer to either a char or a surrogate pair string
					S = char.ConvertFromUtf32(I);
					//'//See if the character is a valid Char
					if (char.TryParse(S, C)) {
						//'//See if the Char is a letter
						if (char.IsLetter(C))
							Ret.Add(C);
					} else if (returnSurrogatePairs) {
						//'//If asked to also return surrogate pairs then do so
						Ret.Add(S);
					}
				}
			}
			return Ret;
		}
		public List<UnicodeRangeInfo> GetUnicodeRanges(string cultureName)
		{
			//'//Get the culture info for the given locale
			System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo(cultureName);
			//'//Create and init our structure that will get passed
			LOCALESIGNATURE FI = new LOCALESIGNATURE();
			FI.Initialize();
			//'//Determine the size of our structure
			object SI = Marshal.SizeOf(FI);
			//'//Call the unmanaged function
			int Result = GetLocaleInfoW(CI.LCID, LOCALE_FONTSIGNATURE, ref FI, SI);
			if (Result == 0) {
				//'//If we get a zero then there's an error. This should call GetLastError ideally
				return null;
			} else {
				//'//The lsUsb field represents a 128 bit value but we pass it into the unmanaged function as an array of 4 integers.
				//'//The code below converts the array of integers to a giant binary string.
				//'//There are of course better ways to do this that will save 5ms but I will leave that to you
				object Usb = Strings.StrReverse(string.Format("{0}{1}{2}{3}", Convert.ToString(FI.lsUsb(3), 2).PadLeft(32, '0'), Convert.ToString(FI.lsUsb(2), 2).PadLeft(32, '0'), Convert.ToString(FI.lsUsb(1), 2).PadLeft(32, '0'), Convert.ToString(FI.lsUsb(0), 2).PadLeft(32, '0')));
				//'//This will be our return ranges
				List<UnicodeRangeInfo> LocaleRanges = new List<UnicodeRangeInfo>();
				int loopI = 0;
				//'//Loop through the bits
				//'//Technically the last couple of bits aren't supposed to be used but there is no value in UnicodeRangeInfo for them anyway so it does not matter
				for (I = 0; I <= (Usb.Length - 1); I++) {
					//'//This is to stop the compiler complaining about lambda expressions
					loopI = I;
					//'//If the bit is set
					if (Usb(I) == '1') {
						//'//Find all ranges in the master range list with that bit set
						LocaleRanges.AddRange(AllRanges.FindAll(n => n.Bit == loopI));
					}
				}
				return LocaleRanges;
			}
		}
		public struct UnicodeRangeInfo
		{
			public string Name { get; set; }
			public int StartRange { get; set; }
			public int EndRange { get; set; }
			public int Bit { get; set; }
			public UnicodeRangeInfo(int bit, int startRange, int endRange, string name)
			{
				this.Bit = bit;
				this.StartRange = startRange;
				this.EndRange = endRange;
				this.Name = name;
			}
			public override string ToString()
			{
				return string.Format("{0}-{1} : {2}", Convert.ToString(this.StartRange, 16).PadLeft(8, '0'), Convert.ToString(this.EndRange, 16).PadLeft(8, '0'), this.Name);
			}
		}
	}
	//=======================================================
	//Service provided by Telerik (www.telerik.com)
	//Conversion powered by NRefactory.
	//Twitter: @telerik
	//Facebook: facebook.com/telerik
	//=======================================================
