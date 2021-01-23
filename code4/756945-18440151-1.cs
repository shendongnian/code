     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BandPage.Models;
    
    namespace BandPage.Helpers
    {
        public static class Widgets
        {
            public static string InsertWidgets(string input)
            {
                BandPageContext context = new BandPageContext();
                input = SocialMedia(input, context.SocialMedias.FirstOrDefault());
                input = GetBlogPosts(input, context.Blogs.OrderByDescending(a => a.Date).Take(3));
                input = RecentBlogs(input, context.Blogs.OrderByDescending(a => a.Date).Take(10));
                input = ContactForm(input);
    
                return input;
            }
    
            public static string SocialMedia(string input, SocialMedia socialMedia)
            {
                string insertCode = "<div class='social-media'>";
                if (!String.IsNullOrEmpty(socialMedia.Facebook))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/facebook.png' /></a>", socialMedia.Facebook); 
                }
                if (!String.IsNullOrEmpty(socialMedia.Myspace))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/myspace.png' /></a>", socialMedia.Myspace);
                }
                if (!String.IsNullOrEmpty(socialMedia.Soundcloud))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/soundcloud.png' /></a>", socialMedia.Soundcloud);
                }
                if (!String.IsNullOrEmpty(socialMedia.Twitter))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/twitter.png' /></a>", socialMedia.Twitter);
                }
                if (!String.IsNullOrEmpty(socialMedia.Instagram))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/instagram.png' /></a>", socialMedia.Instagram);
                }
                if (!String.IsNullOrEmpty(socialMedia.GooglePlus))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/google_plus.png' /></a>", socialMedia.GooglePlus);
                }
                if (!String.IsNullOrEmpty(socialMedia.Youtube))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/youtube.png' /></a>", socialMedia.Youtube);
                }
                if (!String.IsNullOrEmpty(socialMedia.Spotify))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/spotify.png' /></a>", socialMedia.Spotify);
                }
                if (!String.IsNullOrEmpty(socialMedia.Vimeo))
                {
                    insertCode += String.Format("<a href='{0}'><img src='/Images/icons/social-media/vimeo.png' /></a>", socialMedia.Vimeo);
                }
                
                insertCode += "</div>";
    
                // insert the code
                input = input.Replace("[widget=socialmedia]", insertCode);
    
                return input;
            }
    
    
    
            public static string GetBlogPosts(string input, IEnumerable<Blog> blogs)
            {
                string insertCode = "";
    
                foreach (var item in blogs)
                {
                    insertCode += String.Format("<div class='blog-post'><h1>{0} <span class='blog-date sub'>({1}/{2})</span></h1>{3}</div>", 
                        item.Headline, item.Date.Day, item.Date.Month, item.Text);
                }
    
                // insert the code
                input = input.Replace("[widget=blogposts]", insertCode);
    
                return input;
            }
    
            public static string RecentBlogs(string input, IEnumerable<Blog> blogs)
            {
                string insertCode = "<div class='blog-recent'>";
    
                foreach (var item in blogs)
                {
                    insertCode += String.Format("<h4><a href='/blog/{0}'>{1} <span class='blog-date'>({2}/{3})</span></a></h4>", 
                        item.BlogId, item.Headline, item.Date.Day, item.Date.Month);
                }
                insertCode += "</div>";
    
                // insert the code
                input = input.Replace("[widget=recentblogs]", insertCode);
    
                return input;
            }
    
            public static string ContactForm(string input)
            {
                string insertCode =     @"<form id='contact-form'>
                                        <input type='text' name='email' id='email' placeholder='Your e-mail address' />
                                        <input type='text' name='subject' id='subject' placeholder='Subject' />
    
                                        <div class='cheater'>
                                            <input type='text' name='cheater' id='cheater' />
                                        </div>
    
                                        <textarea name='message' id='message' placeholder='Your message'></textarea>
    
                                        <label for='submit'></label>
                                        <input type='submit' name='submit' id='submit' value='Send' class='submit-button' />
                                        </form>
    
                                        <script src='/Scripts/ContactForm.js' type='text/javascript'></script>";
    
                // insert the code
                input = input.Replace("[widget=contactform]", insertCode);
    
                return input;
            }
        }
    }
